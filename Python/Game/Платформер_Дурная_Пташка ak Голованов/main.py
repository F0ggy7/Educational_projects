from random import randint
import pygame
pygame.init()

width_window, height_window = 800, 800
fps = 30

status_game = 'start'
timer = 30
count_frame = 1

scores = 0

pipe_p = {
    "pipe_spead": 5,
    "pipe_gate_size": 250,
    "pipe_gate_pos": height_window // 2,
    "pipe_distance": 280
}

bird_p =  {
    "cord_x" : width_window // 3,
    "cord_y" : height_window // 2,
    "s_bird" : 0,
    "acceleration_y" : 0,
    "width_bird": 60,
    "height_bird": 57
}

img = {
    "bird_down": pygame.image.load('image/sprite_0.png'),
    "bird_up": pygame.image.load('image/sprite_1.png'),
    "bg": pygame.image.load('image/background_land.png'),
    "pipe_top": pygame.image.load('image/pipe2.png'),
    "pipe_bot": pygame.image.load('image/pipe1.png')
}

count_bg = []
pipes = []
pipes_scores = []

pygame.mixer.music.load('sound/muzyka-dlya-igr-38.mp3')
pygame.mixer.music.set_volume(0.2)
pygame.mixer.music.play(-1)

font_small = pygame.font.Font(None, 35)
font_big = pygame.font.Font(None, 50)
sound_lose = pygame.mixer.Sound('sound/GameOver.ogg')

windows = pygame.display.set_mode((width_window, height_window))
clock = pygame.time.Clock()

pygame.display.set_caption('Дураня пчела')

bird = pygame.Rect(bird_p['cord_x'], bird_p['cord_y'], bird_p['width_bird'], bird_p['height_bird'])
count_bg.append(pygame.Rect(0, 0, 2048, 800))

play = True
while play:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            quit()

    count_frame = (count_frame + 1) % 4
    if timer > 0:
        timer -= 1

    press = pygame.mouse.get_pressed()
    key = pygame.key.get_pressed()
    click = press[0] or key[pygame.K_SPACE]
    
    for i in range(len(count_bg)-1, -1, -1):
        bg = count_bg[i]
        bg.x -= pipe_p['pipe_spead'] // 3

        if bg.right < 0:
            count_bg.remove(bg)

        if count_bg[len(count_bg)-1].right <= width_window:
            count_bg.append(pygame.Rect(
                count_bg[len(count_bg)-1].right, 0, 2048, 800))

    for i in range(len(pipes)-1, -1, -1):
        num_pipe = pipes[i]
        num_pipe.x -= pipe_p['pipe_spead']

        if num_pipe.right < 0:
            pipes.remove(num_pipe)
            if num_pipe in pipes_scores:
                pipes_scores.remove(num_pipe)

    if status_game == 'start':
        if click and timer == 0 and len(pipes) == 0:
            status_game = 'play'
        bird_p['cord_y'] += (height_window // 2 -  bird_p['cord_y']) * 0.5
        bird.y = bird_p['cord_y']
        if timer == 0:
            scores = 0

    elif status_game == 'play':
        if click:
            acceleration_y = -3
        else:
            acceleration_y = 0

        bird_p['cord_y'] += bird_p['s_bird']
        bird_p['s_bird'] = (bird_p['s_bird'] + acceleration_y + 1) * 0.98
        bird.y = bird_p['cord_y']

        if bird.top < -bird_p['height_bird'] or bird.bottom > height_window+bird_p['height_bird']:
            status_game = 'fall'

        for num_pipe in pipes:
            if bird.colliderect(num_pipe):
                status_game = 'fall'

            if num_pipe.right < bird.left and num_pipe not in pipes_scores:
                pipes_scores.append(num_pipe)
                scores += 5
                pipe_p['pipe_spead'] = 5 + scores // 100

        if len(pipes) == 0 or pipes[len(pipes)-1].x < width_window - pipe_p['pipe_distance']:
            pipes.append(pygame.Rect(width_window, 0, 100, pipe_p['pipe_gate_pos'] - pipe_p['pipe_gate_size'] // 2))
            pipes.append(pygame.Rect(width_window, pipe_p['pipe_gate_pos'] + pipe_p['pipe_gate_size'] //2, 100, height_window - (pipe_p['pipe_gate_pos'] + pipe_p['pipe_gate_size'] // 2)))

            pipe_p['pipe_gate_pos'] += randint(-170, 170)
            if pipe_p['pipe_gate_pos'] < pipe_p['pipe_gate_size']:
                pipe_p['pipe_gate_pos'] = pipe_p['pipe_gate_size']
            elif pipe_p['pipe_gate_pos'] > height_window - pipe_p['pipe_gate_size']:
                pipe_p['pipe_gate_pos'] = height_window - pipe_p['pipe_gate_size']

    elif status_game == 'fall':
        sound_lose.play()
        bird_p['s_bird'] = 0
        acceleration_y = 0
        pipe_p['pipe_gate_pos'] = height_window // 2
        status_game = 'start'
        timer = 120

    for bg in count_bg:
        windows.blit(img['bg'], bg)

    for num_pipe in pipes:
        if num_pipe.y == 0:
            pos_pipe = img['pipe_top'].get_rect(bottomleft=num_pipe.bottomleft)
            windows.blit(img['pipe_top'], pos_pipe)

        else:
            pos_pipe = img['pipe_bot'].get_rect(topleft=num_pipe.topleft)
            windows.blit(img['pipe_bot'], pos_pipe)

    if count_frame == 0:
        img_bird = pygame.transform.rotate(img['bird_up'], -bird_p['s_bird']*2)
    else:
        img_bird = pygame.transform.rotate(img['bird_down'], -bird_p['s_bird']*2)
    windows.blit(img_bird, bird)

    text_go  = font_big.render("Для старта игры нажмите Пробел или ЛКМ", True, (0, 0, 0))
    text_control  = font_small.render("Для управления также используйте Пробел или ЛКМ", True, (0, 0, 0))
    text_score = font_small.render("Очик: " + str(scores), True, (255, 255, 255))
    
    windows.blit(text_score, (10, 10))

    if status_game == 'start' and timer == 0 :
        windows.blit(text_go, (width_window // 2 - 360, height_window // 3))
        windows.blit(text_control, (width_window // 2 - 310, height_window // 2 - 100))
    
    pygame.display.update()
    clock.tick(fps)
