using CrudEstabelecimentos.Models;
using CrudEstabelecimentos.Repository;
using System;
using System.Globalization;
using System.Web.Mvc;

namespace CrudEstabelecimentos.Controllers
{
    public class EstabelecimentosController : Controller
    {
        public ActionResult EstabelecimentosFirstScreen()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetEstabelecimento()
        {
            var estabelecRepository = new EstabelecimentosRepositorio();
            var resultado = estabelecRepository.GetEstabelecimento();

            resultado.ForEach(estabelecimento => estabelecimento.DataString = estabelecimento.Data_de_Cadastro.ToString("dd/MM/yyyy HH:mm:ss"));

            return Json(new { Lista = resultado }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateEstabelecimentos()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEstabelecimentos(EstabelecimentoModel estabelecimento)
        {

            var Estabelec = new EstabelecimentosRepositorio();
            Estabelec.CreateEstabelecimentos(estabelecimento);


            TempData["Create"] = "ESTABELECIMENTO CRIADO COM SUCESSO!";
            return RedirectToAction("EstabelecimentosFirstScreen");
        }

        public ActionResult UpdateEstabelecimentos(int id)
        {
            var Repositorio = new EstabelecimentosRepositorio();
            var updEst = Repositorio.LfEstabelecimentos(id);
            
            return View(updEst);
        }

        [HttpPost]
        public ActionResult UpdateEstabelecimentos(EstabelecimentoModel estabelecimento)
        {
            var Repositorio = new EstabelecimentosRepositorio();
            Repositorio.UpdateEstabelecimentos(estabelecimento);

            TempData["Edit"] = "ESTABELECIMENTO EDITADO COM SUCESSO!";
            return RedirectToAction("EstabelecimentosFirstScreen");
        }

        public ActionResult DeleteEstabelecimentos(int id)
        {
            var Repositorio = new EstabelecimentosRepositorio();
            Repositorio.DeleteEstabelecimentos(id);

            TempData["Delete"] = "ESTABELECIMENTO DELETADO COM SUCESSO!";
            return RedirectToAction("EstabelecimentosFirstScreen");
        }

    }
}