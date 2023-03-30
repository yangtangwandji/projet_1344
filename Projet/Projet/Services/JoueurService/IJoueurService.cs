using Projet.Models;

namespace Projet.Services.JoueurService
{
    public interface IJoueurService
    {
        Task<List<Joueur>> GetJoueurs();
        Task<Joueur> GetJoueur(int Id);
        Task<Joueur> Create(Joueur joueur);
        Task Update(int id, Joueur joueur);
        void Delete(int Id);

    }
}
