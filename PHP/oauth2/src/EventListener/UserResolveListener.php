<?php

namespace App\EventListener;

use App\Entity\User;
use Doctrine\ORM\EntityManagerInterface;
use Symfony\Component\PasswordHasher\Hasher\UserPasswordHasherInterface;
use Symfony\Component\Security\Core\Exception\AuthenticationCredentialsNotFoundException;
use League\Bundle\OAuth2ServerBundle\Event\UserResolveEvent;

final class UserResolveListener
{

    /**
     * @var UserPasswordHasherInterface
     */

    public function __construct(
        private readonly EntityManagerInterface      $entityManager,
        private readonly UserPasswordHasherInterface $passwordHasher)
    {
    }

    public function onUserResolve(UserResolveEvent $event): void
    {
        $user = $this->entityManager->getRepository(User::class)->findOneBy(['email' => $event->getUsername()]);

        if (!$user) {
            throw  new AuthenticationCredentialsNotFoundException('Пользователь не найден', \Symfony\Component\HttpFoundation\Response::HTTP_NOT_FOUND);
        }

        if (!$this->passwordHasher->isPasswordValid($user, $event->getPassword())) {
            throw  new AuthenticationCredentialsNotFoundException('Пароль не верный', \Symfony\Component\HttpFoundation\Response::HTTP_NOT_FOUND);
        }

        $event->setUser($user);
    }
}