using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Try10projet {
    public class Fournisseur {
        // variables
        private int id;
        private String nom;
        private String ville;
        private int tarif;
        // constructor
        public Fournisseur() {

        }
        public Fournisseur(int id, String nom, String ville, int tarif) {
            this.id = id;
            this.nom = nom;
            this.ville = ville;
            this.tarif = tarif;
        }

        // get-set (2x4)
        public int getId() {
            return this.id; }
        public void setId(int id) {
            this.id = id; }
        public String getNom() {
            return this.nom; }
        public void setNom(String nom) {
            this.nom = nom; }
        public String getVille() {
            return this.ville; }
        public void setVille(String ville) {
            this.ville = ville; }
        public int getTarif() {
            return this.tarif; }
        public void setTarif(int tarif) {
            this.tarif = tarif; }

    }

}
