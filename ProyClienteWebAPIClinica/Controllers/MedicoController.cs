using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;
using ProyClienteWebAPIClinica.Models;
using System.Text;

namespace ProyClienteWebAPIClinica.Controllers
{
    public class MedicoController : Controller
    {
        // GET: MedicoController
        public async Task<ActionResult> IndexMedico() // List
        {
            var listado = new List<Medico>();
            //
            using (HttpClient cliente = new HttpClient())
            {
                // realizar la solicitud de un método web al servicio web
                var rpta = await cliente.GetAsync(
                    "https://localhost:7285/api/MedicoAPI/GetMedicos");
                // recuperar la cadena devuelta por la ejecución del método
                string contenido = await rpta.Content.ReadAsStringAsync();
                // deserializar el valor de la variable "contenido" en un List<Medico>
                listado = JsonConvert.DeserializeObject<List<Medico>>(contenido);
            }
            //
            return View(listado);
        }

        // GET: MedicoController/Details/5
        public async Task<ActionResult> DetailsMedico(string id)
        {
            var listado = new Medico();
            //
            using (HttpClient cliente = new HttpClient())
            {
                // realizar la solicitud de un método web al servicio web
                var rpta = await cliente.GetAsync(
                    $"https://localhost:7285/api/MedicoAPI/GetBuscarMedico/{id}");
                // recuperar la cadena devuelta por la ejecución del método
                string contenido = await rpta.Content.ReadAsStringAsync();
                // deserializar el valor de la variable "contenido" en un List<Medico>
                listado = JsonConvert.DeserializeObject<Medico>(contenido);
            }
            //
            return View(listado);
        }

        // GET: MedicoController/Create
        public ActionResult CreateMedico()
        {
            return View(new Medico());
        }

        // POST: MedicoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateMedico(Medico obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (HttpClient cliente = new HttpClient())
                    {
                        // obj.Eliminado = "No";
                        // convertir la variable obj a Json
                        StringContent contenido = new StringContent(
                            JsonConvert.SerializeObject(obj),
                            Encoding.UTF8,
                            "application/json");
                        //
                        var rpta = await cliente.PostAsync(
                            "https://localhost:7285/api/MedicoAPI/PostMedico",
                            contenido);
                        //
                        TempData["mensaje"] = await rpta.Content.ReadAsStringAsync();
                        //return RedirectToAction(nameof(IndexMedico));
                        return RedirectToAction("IndexMedico");
                    }
                }
            }
            catch(Exception ex)
            {
                ViewBag.mensaje = ex.Message;
            }
            return View(obj);
        }

        // GET: MedicoController/Edit/5
        public async Task<ActionResult> EditMedico(string id)
        {
            var listado = new Medico();
            //
            using (HttpClient cliente = new HttpClient())
            {
                // realizar la solicitud de un método web al servicio web
                var rpta = await cliente.GetAsync(
                    $"https://localhost:7285/api/MedicoAPI/GetMedico/{id}");
                // recuperar la cadena devuelta por la ejecución del método
                string contenido = await rpta.Content.ReadAsStringAsync();
                // deserializar el valor de la variable "contenido" en un List<Medico>
                listado = JsonConvert.DeserializeObject<Medico>(contenido);
            }
            //
            return View(listado);
        }

        // POST: MedicoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditMedico(string id, Medico obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (HttpClient cliente = new HttpClient())
                    {
                        // obj.Eliminado = "No";
                        // convertir la variable obj a Json
                        StringContent contenido = new StringContent(
                            JsonConvert.SerializeObject(obj),
                            Encoding.UTF8,
                            "application/json");
                        //
                        var rpta = await cliente.PutAsync(
                            "https://localhost:7285/api/MedicoAPI/EditarMedico",
                            contenido);
                        //
                        TempData["mensaje"] = await rpta.Content.ReadAsStringAsync();
                        //return RedirectToAction(nameof(IndexMedico));
                        return RedirectToAction("IndexMedico");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.mensaje = ex.Message;
            }
            return View(obj);
        }

        // GET: MedicoController/Delete/5
        public async Task<ActionResult> DeleteMedico(string id)
        {
            var listado = new Medico();
            //
            using (HttpClient cliente = new HttpClient())
            {
                // realizar la solicitud de un método web al servicio web
                var rpta = await cliente.GetAsync(
                    $"https://localhost:7285/api/MedicoAPI/GetBuscarMedico/{id}");
                // recuperar la cadena devuelta por la ejecución del método
                string contenido = await rpta.Content.ReadAsStringAsync();
                // deserializar el valor de la variable "contenido" en un List<Medico>
                listado = JsonConvert.DeserializeObject<Medico>(contenido);
            }
            //
            return View(listado);
        }

        // POST: MedicoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteMedico(string id, IFormCollection collection)
        {
            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    // realizar la solicitud de un método web al servicio web
                    var rpta = await cliente.DeleteAsync(
                        $"https://localhost:7285/api/MedicoAPI/BorrarMedico/{id}");
                    // recuperar la cadena devuelta por la ejecución del método
                    TempData["mensaje"] = await rpta.Content.ReadAsStringAsync();
                    //
                    return RedirectToAction(nameof(IndexMedico));
                }
            }
            catch (Exception ex)
            {
                ViewBag.mensaje = ex.Message;
            }
            //
            var obj = new Medico();
            //
            using (HttpClient cliente = new HttpClient())
            {
                // realizar la solicitud de un método web al servicio web
                var rpta = await cliente.GetAsync(
                    $"https://localhost:7285/api/MedicoAPI/GetBuscarMedico/{id}");
                // recuperar la cadena devuelta por la ejecución del método
                string contenido = await rpta.Content.ReadAsStringAsync();
                // deserializar el valor de la variable "contenido" en un List<Medico>
                obj = JsonConvert.DeserializeObject<Medico>(contenido);
            }
            //
            return View(obj);
        }
        }
    
}
