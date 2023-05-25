import telebot
import pandas as pd
import re
from nltk import word_tokenize, pos_tag
from nltk.stem import wordnet
from nltk. corpus import stopwords
from sklearn. feature_extraction.text import CountVectorizer
from sklearn.metrics import pairwise_distances

API_TOKEN = "5889372451:AAGbvR4sGigVcmUBAHQsJE_bL6XP2btYLhE"
bot = telebot.TeleBot(API_TOKEN)      

@bot.message_handler(commands=['help', 'start'])
def send_welcome(message):
    bot.reply_to(message, """\
Hello, I'm a support bot.
You can ask me a question and I will try to answer it or get you down to the support service.\
""")

@bot.message_handler(content_types=['text'])
def send_echo(message):

    def textnotmalize(text):
        words = str(text).lower()
        words = re.sub(r'[^a-z0-9]', ' ', words)
        token =  word_tokenize(words)
        tags = pos_tag(token)
        lem_list = []
        lemm = wordnet.WordNetLemmatizer()
        for word, tag in tags:
            if tag.startswith('V'):
                pos_val = 'v'
            elif tag.startswith('J'):
                pos_val = 'a'
            elif tag.startswith ('R'):
                pos_val = 'r'
            else:
                pos_val= 'n'
            lemm_token = lemm.lemmatize (word, pos_val)
            lem_list.append (lemm_token)
        return' '.join (lem_list)

    df = pd.read_excel('dialog_talk_agent.xlsx')
    df.ffill(axis = 0, inplace=True)

    df['Lemmatize'] = df['Context'].apply(textnotmalize)

    cv = CountVectorizer()
    X = cv.fit_transform(df['Lemmatize']).toarray()
    features = cv.get_feature_names()
    df_bow = pd.DataFrame(X, columns=features)

    Quest = message.text
    Q = []
    a = Quest.split()

    stop = stopwords.words()
    for word in a:
        if word not in stop:
            Q.append(word)
    Q = ' '.join(Q)

    Q = textnotmalize(Q)
    Q_bow = cv.transform([Q]).toarray()

    cosine_value = 1 - pairwise_distances(df_bow, Q_bow, metric = 'cosine')
    df['Simil'] = cosine_value

    ans_ind = cosine_value.argmax()
    ans =  df['Text Response'].loc[ans_ind]

    if ans_ind != 0:
        bot.reply_to(message, ans)
    else: 
        bot.forward_message(chat_id = -708558851, from_chat_id = message.chat.id, message_id = message.message_id) 


bot.infinity_polling()