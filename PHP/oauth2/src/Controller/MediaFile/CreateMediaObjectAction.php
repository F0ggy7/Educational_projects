<?php
// api/src/Controller/CreateMediaObjectAction.php

namespace App\Controller\MediaFile;

use App\Entity\MediaObject;
use Doctrine\ORM\EntityManagerInterface;
use Imagine\Image\ImageInterface;
use Symfony\Bundle\FrameworkBundle\Controller\AbstractController;
use Symfony\Bundle\SecurityBundle\Security;
use Symfony\Component\HttpFoundation\Request;
use Symfony\Component\HttpKernel\Attribute\AsController;
use Symfony\Component\HttpKernel\Exception\BadRequestHttpException;
use Imagine\Gd\Imagine;
use Imagine\Image\Box;

#[AsController]
final class CreateMediaObjectAction extends AbstractController
{
    private Security $security;
    private $imagine;

    public function __construct(Security $security)
    {
        $this->security = $security;
        $this->imagine = new Imagine();
    }

    public function __invoke(Request $request, EntityManagerInterface $entityManager): MediaObject
    {
        $uploadedFile = $request->files->get('file');

        if (!$uploadedFile) {
            throw new BadRequestHttpException('"file" is required');
        }

        $mediaObject = new MediaObject();
        $mediaObject->file = $uploadedFile;

        $user = $this->security->getUser();
        $mediaObject->setUser($user);

        $entityManager->persist($mediaObject);
        $entityManager->flush();

        $filePath = $mediaObject->file->getPathname();
        list($iwidth, $iheight) = getimagesize($filePath);
        $width = $iwidth * 0.8;
        $height = $iheight * 0.8;

        $photo = $this->imagine->open($filePath);
        $photo->resize(new Box($width, $height),ImageInterface::FILTER_BOX)->save($filePath);

        return $mediaObject;
    }
}