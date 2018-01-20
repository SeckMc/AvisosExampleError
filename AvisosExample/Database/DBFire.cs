using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AvisosExample.Model;
using Firebase.Xamarin.Database;

namespace AvisosExample.Database
{
    public class DBFire
    {
		FirebaseClient fbClient;

		public DBFire()
		{
			fbClient = new FirebaseClient("https://itslrapp.firebaseio.com/");
		}

		public async Task<List<Avisos>> getRoomList()
		{
			return (await fbClient
				.Child("AvisosApp")
					.OnceAsync<Avisos>())
				.Select((item) =>
						new Avisos
						{
							descripcion = item.Object.descripcion,
							imagenURL = item.Object.imagenURL,
							fecha = item.Object.fecha,
							Titulo = item.Object.Titulo
						}

					   ).ToList();

		}

		public async Task saveRoom(Avisos rm)
		{
			await fbClient.Child("AvisosApp")
					.PostAsync(rm);

		}
    }
}
