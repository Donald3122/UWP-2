using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;

namespace _11.Models
{
    internal class ImageHelper
    {
        // Список имен файлов, которые нужно скопировать
        private static readonly string[] ImageFileNames = new string[]
        {
            "product1.png", "product2.png", "product3.png",
            "product4.png", "product5.png", "product6.png",
            "product7.png", "product8.png", "product9.png",
            "product10.png", "product11.png", "product12.png",
            "product13.png", "product14.png", "product15.png",
            "product16.png", "product17.png", "product18.png",
            "product19.png", "product20.png",
            
        };

        public static async Task CopyImagesToLocalFolderAsync()
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFolder assetsFolder = await StorageFolder.GetFolderFromPathAsync(System.IO.Path.Combine(Windows.ApplicationModel.Package.Current.InstalledLocation.Path, "Assets"));

            foreach (string fileName in ImageFileNames)
            {
                // Проверяем, существует ли файл в локальной папке
                StorageFile file = await localFolder.TryGetItemAsync(fileName) as StorageFile;
                if (file == null)
                {
                    // Копируем файл из папки Assets в локальную папку
                    StorageFile sourceFile = await assetsFolder.GetFileAsync(fileName);
                    await sourceFile.CopyAsync(localFolder);
                }
            }
        }

        public static async Task<bool> CheckIfImageExistsAsync(string fileName)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await localFolder.TryGetItemAsync(fileName) as StorageFile;
            return file != null;
        }
    }
}
