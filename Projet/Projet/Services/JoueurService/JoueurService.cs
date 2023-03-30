#nullable disable
using Microsoft.EntityFrameworkCore;
using Projet.Models;

namespace Projet.Services.JoueurService
{
    public class JoueurService : IJoueurService
    {
        private readonly ApiContext _context;

        public JoueurService(ApiContext context)
        {
            _context = context;
        }

        public async Task<List<Joueur>> GetJoueurs()
        {
            return await _context.Joueurs.ToListAsync();
        }

        public async Task<Joueur> GetJoueur(int Id)
        {
            return await _context.Joueurs.Where(j => j.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<Joueur> Create(Joueur joueur)
        {
            try
            {
                await _context.AddAsync(joueur);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

            return joueur;
        }

        public async Task Update(int id,Joueur joueur)
        {
            var oldJ = await _context.Joueurs.Where(j => j.Id == id).FirstOrDefaultAsync();
            if (oldJ !=null)
            {
                oldJ.Age = joueur.Age;
                oldJ.Nom = joueur.Nom;
                oldJ.Prenom = joueur.Prenom;
            }

            _context.Update(oldJ);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var j = _context.Joueurs.Where(j => j.Id == Id).FirstOrDefault();

            if (j != null)
            {
                _context.Remove(j);
                _context.SaveChanges();
            }

        }
    }
}
