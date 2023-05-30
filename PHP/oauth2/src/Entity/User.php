<?php

namespace App\Entity;

use ApiPlatform\Doctrine\Orm\Filter\OrderFilter;
use ApiPlatform\Doctrine\Orm\Filter\SearchFilter;
use ApiPlatform\Metadata\ApiFilter;
use ApiPlatform\Metadata\ApiResource;
use ApiPlatform\Metadata\Delete;
use ApiPlatform\Metadata\Get;
use ApiPlatform\Metadata\GetCollection;
use ApiPlatform\Metadata\Post;
use ApiPlatform\Metadata\Put;
use App\Controller\User\RegistrationController;
use App\Repository\UserRepository;
use Doctrine\Common\Collections\ArrayCollection;
use Doctrine\Common\Collections\Collection;
use Doctrine\ORM\Mapping as ORM;
use Symfony\Component\Security\Core\User\PasswordAuthenticatedUserInterface;
use Symfony\Component\Security\Core\User\UserInterface;
use Symfony\Component\Serializer\Annotation\Groups;

#[ORM\Entity(repositoryClass: UserRepository::class)]
#[ApiResource(operations: [
    new Post(
        uriTemplate: 'user/register',
        controller: RegistrationController::class,
        denormalizationContext: ['groups' => 'createUser'],
        normalizationContext: ['groups' => 'getUser']
    ),
    new Get(
        normalizationContext: ['groups' => 'getUser'],
    ),
    new GetCollection(
        normalizationContext: ['groups' => 'getUser']
    ),
    new Put(
        controller: RegistrationController::class,
        denormalizationContext: ['groups' => 'createUser']
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
class User extends BaseEntity implements UserInterface, PasswordAuthenticatedUserInterface
{
    #[ORM\Column(length: 180, unique: true)]
    #[Groups(['createUser', 'getUser'])]
    private ?string $email = null;

    #[ORM\Column]
    private array $roles = [];

    /**
     * @var string The hashed password
     */
    #[ORM\Column]
    #[Groups('createUser')]
    private ?string $password = null;

    /**
     * @var MediaObject[]
     */
    #[ORM\OneToMany(mappedBy: "user", targetEntity: "MediaObject")]
    private iterable $images = [];

    public function getEmail(): ?string
    {
        return $this->email;
    }

    public function setEmail(string $email): self
    {
        $this->email = $email;

        return $this;
    }

    /**
     * A visual identifier that represents this user.
     *
     * @see UserInterface
     */
    public function getUserIdentifier(): string
    {
        return (string)$this->email;
    }

    /**
     * @see UserInterface
     */
    public function getRoles(): array
    {
        $roles = $this->roles;
        // guarantee every user at least has ROLE_USER
        $roles[] = 'ROLE_USER';

        return array_unique($roles);
    }

    public function setRoles(array $roles): self
    {
        $this->roles = $roles;

        return $this;
    }

    /**
     * @see PasswordAuthenticatedUserInterface
     */
    public function getPassword(): string
    {
        return $this->password;
    }

    public function setPassword(string $password): self
    {
        $this->password = $password;

        return $this;
    }

    /**
     * @see UserInterface
     */
    public function eraseCredentials()
    {
        // If you store any temporary, sensitive data on the user, clear it here
        // $this->plainPassword = null;
    }

    public function __construct()
    {
        $this->images = new ArrayCollection();
    }

    public function getImage(): Collection
    {
        return $this->images;
    }

    public function addImage(MediaObject $mediaObject): self
    {
        if (!$this->images->contains($mediaObject)) {
            $this->images[] = $mediaObject;
            $mediaObject->setUser($this);
        }
        return $this;
    }
}
