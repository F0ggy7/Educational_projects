from ctypes.wintypes import SIZE
from operator import truediv
from optparse import Option
from platform import python_branch
import random
from tkinter.tix import Tree
from turtle import color
import pygame
import sys

pygame.init()

size = 30
half_size = size // 2
count_blocks = 21
margin = 1
side_margin = 5

snake_start_pos = side_margin+(size+margin)*(count_blocks//2)
length = 4
score = 0

config = {
    "res": side_margin*2+size*count_blocks+margin*20,
    "FPS": 40,
    "snake_frame_speed": 5,
    "frame_counter": 0
}

colors = {
    "screen_fill": (0, 250, 200),
    "snake_body": (0, 160, 0),
    "snake_head": (0, 230, 10),
    "aplle": (200, 0, 0),
    "rect1": (30, 20, 30),
    "rect2": (100, 100, 20),
    "end": (255,140,0)
}

direction = {
    "w": (0, - size-margin),
    "s": (0, +size+margin),
    "a": (-size-margin, 0),
    "d": (size+margin, 0),
    "dirX": (0),
    "dirY": (size+1)
}

clock = pygame.time.Clock()
screen = pygame.display.set_mode((config["res"], config["res"]))

snake = [(snake_start_pos, snake_start_pos)]

pygame.mixer.music.load("sound/laxity-crosswords-by-seraphic-music.mp3")
pygame.mixer.music.play(-1)
pygame.mixer.music.set_volume(0.1)

eat = pygame.mixer.Sound("sound/igrovaya-sreda-audio-energoobespechenie-audio-material-39368.ogg")
lose = pygame.mixer.Sound('sound/zvuk-smerti-v-igre.ogg')

pygame.font.match_font('Arial')
font_end_game = pygame.font.SysFont('Arial', 72, True)


# функция генерации координат яблок и увеличения длинный
def apple_gen():
    global apple, score, length, snake
    apple = (random.randrange(side_margin, config["res"] - size-side_margin, size+margin),
             random.randrange(side_margin, config["res"] - size-side_margin, size+margin))
    for snake_num in range(len(snake)):
        if apple[0] == snake[snake_num][0] and apple[1] == snake[snake_num][1]:
            apple_gen()
    score += 1
    length += 1

# Функция отрисовки блоков
def draw_blocks(color_rec, column, row):
    pygame.draw.rect(screen, color_rec, [side_margin+column*size+margin*column, side_margin+row*size+margin*row, size, size])

# Функция закрытия игры
def leave():
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            quit()


# Спавним яблоко в начале игры
apple_gen()

game_end = False

while not game_end:
    config["frame_counter"] += 1
    leave()
    pygame.display.set_caption("Змейка. Счет: " + str(score))

    # Отрисовка поля
    screen.fill(colors["screen_fill"])
    for row in range(count_blocks):
        for column in range(count_blocks):
            if (column+row) % 2 == 0:
                color_rec = colors["rect1"]
            else:
                color_rec = colors["rect2"]
            draw_blocks(color_rec, column, row)

    # Отрисовываем змейку
    [pygame.draw.rect(screen, colors["snake_body"], (x, y, size, size))for x, y in snake]
    pygame.draw.rect(screen, colors["snake_head"], (snake[-1][0], snake[-1][1], size, size))

    # Рисуем яблоко
    pygame.draw.circle(
        screen, colors["aplle"], (apple[0] + half_size, apple[1] + half_size), half_size)

    # Респавн яблока и звук поедания
    if apple[0] == snake[-1][0] and apple[1] == snake[-1][1]:
        eat.play()
        apple_gen()

    # Нажатие клавиши
    key = pygame.key.get_pressed()
    if key[pygame.K_w]:
        if (direction["dirX"], direction["dirY"]) != direction['s']:
            direction["dirX"], direction["dirY"] = direction['w']
    elif key[pygame.K_s]:
        if (direction["dirX"], direction["dirY"]) != direction['w']:
            direction["dirX"], direction["dirY"] = direction['s']
    if key[pygame.K_a]:
        if (direction["dirX"], direction["dirY"]) != direction['d']:
            direction["dirX"], direction["dirY"] = direction['a']
    elif key[pygame.K_d]:
        if (direction["dirX"], direction["dirY"]) != direction['a']:
            direction["dirX"], direction["dirY"] = direction['d']

    # Движение змейки
    if config["frame_counter"] % config["snake_frame_speed"] == 0:
        newX = snake[-1][0] + direction["dirX"]
        newY = snake[-1][1] + direction["dirY"]
        snake.append((newX, newY))
        snake = snake[-length+1:]
        #print ('Змеюка ',  snake)
        #print ('Яблуко ', apple)

    # Проигрыш
    if snake[-1][0] <= - size+side_margin or snake[-1][0] >= config["res"]-side_margin or snake[-1][1] <= -size+side_margin or snake[-1][1] >= config["res"]-side_margin or len(snake) != len(set(snake)):
        pygame.mixer.music.stop()
        lose.play()
        end_render = font_end_game.render('Game Over', True, colors["end"])
        screen.blit(end_render, (140, config["res"]//2-36))
        pygame.display.update()

        while True:
            leave()

    clock.tick(config["FPS"])
    pygame.display.flip()
