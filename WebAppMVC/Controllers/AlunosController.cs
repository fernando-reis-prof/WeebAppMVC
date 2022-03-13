using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Repositories;
using WebAppMVC.ViewModels;

namespace WebAppMVC.Controllers
{
    public class AlunosController : Controller
    {
        // GET: AlunosController
        public ActionResult Index()
        {
            List<AlunoViewModel> alunos = AlunoRepository.GetAll();
            return View(alunos);
        }

        // POST: AlunosController/xxx
        [HttpPost]
        public ActionResult Index(string searchString)
        {
            List<AlunoViewModel> alunos = new List<AlunoViewModel>();

            if (!String.IsNullOrEmpty(searchString))
            {
                alunos = AlunoRepository.GetBySearch(searchString);
            }
            else 
            { 
                alunos = AlunoRepository.GetAll();
            }
            return View(alunos);
        }


        // GET: AlunosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AlunosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AlunoViewModel aluno)
        {
            try
            {
                AlunoRepository.Create(aluno);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(aluno);
            }
        }

        // GET: AlunosController/Details/5
        public ActionResult Details(int id)
        {
            var aluno = AlunoRepository.GetById(id);
            return View(aluno);
        }

        // GET: AlunosController/Edit/5
        public ActionResult Edit(int id)
        {
            var aluno = AlunoRepository.GetById(id);
            return View(aluno);
        }

        // POST: AlunosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AlunoViewModel aluno)
        {
            try
            {
                AlunoRepository.Update(aluno);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AlunosController/Delete/5
        public ActionResult Delete(int id)
        {
            var aluno = AlunoRepository.GetById(id);
            return View(aluno);
        }

        // POST: AlunosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AlunoViewModel aluno)
        {
            try
            {
                AlunoRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
