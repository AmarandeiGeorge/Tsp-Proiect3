using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Photos;
using Photos_Apsnet.Models;
namespace Photos_Apsnet
{
    public class PhotoViewModel : PageModel
    {
        ServiceWCFClient service = new ServiceWCFClient();
        public List<PhotoDto2> Photos { get; set; }
        public List<PhotoDto2> PhotosFiltered { get; set; }
        public List<string> Properties { get; set; }
        public int Count { get; set; }
        public PhotoViewModel()
        {
            Photos = new List<PhotoDto2>();
            PhotosFiltered = new List<PhotoDto2>();
            Properties = new List<string>();
            Count = 0;
        }
        public async Task OnGetAsync()
        {
            var photos =await service.GetAllAsync();
            foreach( var photo in photos)
            {
                PhotoDto2 elem = new PhotoDto2()
                {
                    Titlu = photo.Titlu,
                    Descriere = photo.Descriere,
                    Path = photo.Path,
                    Eveniment = photo.Eveniment,
                    Other = photo.Other.Split(';')
                };
                Photos.Add(elem);
                string[] props = photo.Other.Split(';');
                foreach(string prop in props)
                {
                    if (!Properties.Contains(prop))
                    {
                        Properties.Add(prop);
                    }
                }

            }
            PhotosFiltered = Photos;
            Count = PhotosFiltered.Count;
        }
        public void OnPost()
        {
            string searchString = Request.Form["search"];
            if(searchString!=null)
            PhotosFiltered = Photos.Where(s => s.Other.Contains(searchString)).ToList();
        }
    }
}