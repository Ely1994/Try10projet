using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Try10projet {
    class DBFournisseur {
        // variables
        private string connectionString;
        // Constructor
        public DBFournisseur() {
            Initialize();
        }
        /// <summary>
        /// Initialise les champs et cree un objet connection.
        /// </summary>
        private void Initialize() {
            string server = "localhost";
            string port = "3306";
            string database = "try10projet";
            string uid = "root";
            string password = "";
            connectionString = "SERVER=" + server + ";" + "PORT=" + port + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

        }

        /// <summary>
        /// La méthode Read retourne un fournisseur en fonction de l'id dans la table. 
        /// </summary>
        /// <param name="id">id du fournisseur recherché</param>
        /// <returns></returns>
        public Fournisseur Read(int id) {
            Fournisseur leFournisseur = null; 
           
            using (MySqlConnection connection = new MySqlConnection(connectionString)) {
                connection.Open();
                string query = "SELECT * FROM Fournisseur where id=@id";

                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);

                //Create a data reader and Execute the command
                using (MySqlDataReader dataReader = cmd.ExecuteReader()) {

                    //Read the data and store them in the list
                    while (dataReader.Read()) {
                        leFournisseur = new Fournisseur();
                        leFournisseur.setId((int)dataReader["id"]);
                        leFournisseur.setNom((string)dataReader["nom"]);
                        leFournisseur.setVille((string)dataReader["ville"]);
                        leFournisseur.setTarif(dataReader["tarif"] != DBNull.Value ? (int)dataReader["tarif"] : 0);
                    }

                }
                
            }
            return leFournisseur;
        }
        public List<Fournisseur> ReadAll() {
            List<Fournisseur> lesFournisseurs = new List<Fournisseur>();

            using (MySqlConnection connection = new MySqlConnection(connectionString)) {
                connection.Open();
                string query = "SELECT * FROM Fournisseur";
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Create a data reader and Execute the command
                using (MySqlDataReader dataReader = cmd.ExecuteReader()) {

                    //Read the data and store them in the list
                    while (dataReader.Read()) {


                        Fournisseur unFournisseur = new Fournisseur((int)dataReader["id"], (string)dataReader["nom"], (string)dataReader["ville"], (int)dataReader["tarif"]);
                        lesFournisseurs.Add(unFournisseur);
                    }
                    

                }

            }
            return lesFournisseurs;
        }
        public void Add(String nom, String ville, int tarif) {
            using (MySqlConnection connection = new MySqlConnection(connectionString)) {
                connection.Open();
                String query = "INSERT INTO Fournisseur (nom, ville, tarif) VALUES (@nom, @ville, @tarif)";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@ville", ville);
                cmd.Parameters.AddWithValue("@tarif", tarif);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
