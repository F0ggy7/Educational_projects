<?php
// api/src/Entity/MediaObject.php
namespace App\Entity;

use ApiPlatform\Doctrine\Orm\Filter\OrderFilter;
use ApiPlatform\Doctrine\Orm\Filter\SearchFilter;
use ApiPlatform\Metadata\ApiFilter;
use ApiPlatform\Metadata\ApiProperty;
use ApiPlatform\Metadata\ApiResource;
use ApiPlatform\Metadata\Delete;
use ApiPlatform\Metadata\Get;
use ApiPlatform\Metadata\GetCollection;
use ApiPlatform\Metadata\Post;
use ApiPlatform\OpenApi\Model;
use App\Controller\MediaFile\GetCollectionMediaObjectAction;
use App\Controller\MediaFile\CreateMediaObjectAction;
use Doctrine\ORM\Mapping as ORM;
use Symfony\Component\HttpFoundation\File\File;
use Symfony\Component\Serializer\Annotation\Groups;
use Symfony\Component\Validator\Constraints as Assert;
use Vich\UploaderBundle\Mapping\Annotation as Vich;

#[Vich\Uploadable]
#[ORM\Entity]
#[ApiResource(
    normalizationContext: ['groups' => ['media_object:read']],
    types: ['https://schema.org/MediaObject'],
    operations: [
        new Get(
            security:"is_granted('ROLE_USER')"
        ),
        new GetCollection(
            controller: GetCollectionMediaObjectAction::class,
            security:"is_granted('ROLE_USER')"
        ),
        new Post(
            controller: CreateMediaObjectAction::class,
            security:"is_granted('ROLE_USER')",
            deserialize: false,
            validationContext: ['groups' => ['Default', 'media_object_create']],
            openapi: new Model\Operation(
                requestBody: new Model\RequestBody(
                    content: new \ArrayObject([
                        'multipart/form-data' => [
                            'schema' => [
                                'type' => 'object',
                                'properties' => [
                                    'file' => [
                                        'type' => 'string',
                                        'format' => 'binary'
                                    ]
                                ]
                            ]
                        ]
                    ])
                )
            )
        ),
        new Delete()
    ]
)]
#[ApiFilter(
    SearchFilter::class,
    properties: ['id' => SearchFilter::DOCTRINE_INTEGER_TYPE]
)]
#[ApiFilter(
    OrderFilter::class,
    properties: ['dateCreate']
)]
class MediaObject extends BaseEntity
{
    #[ApiProperty(types: ['https://schema.org/contentUrl'])]
    #[Groups(['media_object:read'])]
    public ?string $contentUrl = null;

    #[ORM\ManyToOne(targetEntity: "User", inversedBy: "mediaObject")]
    #[ORM\JoinColumn(nullable: true)]
    private User $user;

    #[Vich\UploadableField(mapping: "media_object", fileNameProperty: "filePath")]
    #[Assert\NotNull(groups: ['media_object_create'])]
    public ?File $file = null;

    #[ORM\Column(nullable: true)]
    public ?string $filePath = null;

    /**
     * @return User|null
     */
    public function getUser(): ?User
    {
        return $this->user;
    }

    /**
     * @param User|null $user
     */
    public function setUser(?User $user): void
    {
        $this->user = $user;
        $user?->addImage($this);
    }
}