using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GrupoOneParx.WEB.ViewModel;
using AutoMapper;
using GrupoOneParx.Business.Interfaces;
using GrupoOneParx.Business.Models;

namespace GrupoOneParx.WEB.Controllers
{
    public class EmpresaController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaController(IEmpresaRepository empresaRepository, IMapper mapper)
        {
            _mapper = mapper;
            _empresaRepository = empresaRepository;

        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<EmpresaViewModel>>(await _empresaRepository.ObterTodos()));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var empresaViewModel = await ObterPorId(id.Value);

            if (empresaViewModel == null)
                return NotFound();

            return View(empresaViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Site,QuantidadeFuncionarios")] EmpresaViewModel empresaViewModel)
        {
            if (!ModelState.IsValid)
                return View(empresaViewModel);

            Empresa empresa = _mapper.Map<Empresa>(empresaViewModel);
            await _empresaRepository.Adicionar(empresa);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var empresaViewModel = await ObterPorId(id.Value);

            if (empresaViewModel == null)
                return NotFound();

            return View(empresaViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Site,QuantidadeFuncionarios")] EmpresaViewModel empresaViewModel)
        {
            if (id != empresaViewModel.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(empresaViewModel);

            Empresa empresa = _mapper.Map<Empresa>(empresaViewModel);

            await _empresaRepository.Atualizar(empresa);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var empresaViewModel = await ObterPorId(id.Value);
            if (empresaViewModel == null)
                return NotFound();

            return View(empresaViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Empresa empresa = await _empresaRepository.ObterPorId(id);

            if (empresa != null)
                await _empresaRepository.Remover(empresa);

            return RedirectToAction("Index");
        }

        private async Task<EmpresaViewModel> ObterPorId(int id)
        {
            return _mapper.Map<EmpresaViewModel>(await _empresaRepository.ObterPorId(id));
        }
    }
}
