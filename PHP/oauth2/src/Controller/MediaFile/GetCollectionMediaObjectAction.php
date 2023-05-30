<?php

namespace App\Controller\MediaFile;

use App\Entity\MediaObject;
use Doctrine\ORM\EntityManagerInterface;
use Symfony\Bundle\FrameworkBundle\Controller\AbstractController;
use Symfony\Component\HttpKernel\Attribute\AsController;
use Symfony\Component\HttpKernel\Exception\BadRequestHttpException;
use Symfony\Bundle\SecurityBundle\Security;

#[AsController]
final class GetCollectionMediaObjectAction extends AbstractController
{
    private Security $security;

    public function __construct(Security $security)
    {
        $this->security = $security;
    }

    public function __invoke(EntityManagerInterface $entityManager): array
    {
        $user = $this->security->getUser();
        if (!$user) {
            throw new BadRequestHttpException('User not authenticated');
        }

        return $entityManager->getRepository(MediaObject::class)->findBy(['user' => $user]);
    }
}