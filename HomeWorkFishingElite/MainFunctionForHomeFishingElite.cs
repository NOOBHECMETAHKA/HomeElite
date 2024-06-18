using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows;
using System.Reflection.Emit;
using System.Windows.Media.Media3D;

namespace HomeWorkFishingElite
{
    public class MainFunctionForHomeFishingElite
    {
        FishingEliteEntities db;

        public MainFunctionForHomeFishingElite()
        {
            db = new FishingEliteEntities();
        }

        public MainFunctionForHomeFishingElite(FishingEliteEntities db)
        {
            this.db = db;
        }

        public string hashStringByMD5(string password)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = MD5.Create().ComputeHash(bytes);
            return BitConverter.ToString(hash).Replace("-", "");
        }

        public List<responsbilities> authUserByLoginAndPassword(string login, string password)
        {
            string hashLogin = hashStringByMD5(login);
            string hashPassword = hashStringByMD5(password);

            List<employee> people = db.employee.Where(p => p.login.Equals(hashLogin) && p.password.Equals(hashPassword)).ToList();

            if (people.Count == 0)
            {
                return null;
            }

            employee person = people.FirstOrDefault();
            return person.responsbilities.ToList();
        }

        public void printMessage(string message, MessageBoxImage image)
        {
            MessageBox.Show(message, "Элитная рыбалка", MessageBoxButton.OK, image);
        }

        public List<fishing_asset> getFishingAsset()
        {
            return db.fishing_asset.ToList();
        }

        public List<category> getCategory()
        {
            return db.category.ToList();
        }

        public bool deleteFishingAsset(fishing_asset fishingAsset)
        {
            db.fishing_asset.Remove(fishingAsset);
            db.SaveChanges();
            printMessage("Успешное удаление", MessageBoxImage.Information);
            return true;
        }

        public bool addFishingAsset(fishing_asset fishingAsset)
        {
            db.fishing_asset.Add(fishingAsset);
            db.SaveChanges();
            printMessage("Успешное добавлен", MessageBoxImage.Information);
            return true;
        }
    }
}
