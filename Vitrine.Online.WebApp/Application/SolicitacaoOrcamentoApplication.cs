using Vitrine.Online.Core.Models.SolicitacaoOrcamento;
using Vitrine.Online.Core.Services.Intefaces;
using Vitrine.Online.WebApp.Application.Interfaces;
using Vitrine.Online.WebApp.Models;

namespace Vitrine.Online.WebApp.Application
{
    public class SolicitacaoOrcamentoApplication : ISolicitacaoOrcamentoApplication
    {
        private readonly ISolicitacaoOrcamentoService _solicitacaoOrcamentoService;
        public SolicitacaoOrcamentoApplication(ISolicitacaoOrcamentoService solicitacaoOrcamentoServices)
        {
            _solicitacaoOrcamentoService = solicitacaoOrcamentoServices;
        }
        public async Task<bool> InserirSolicitacao(SolicitacaoOrcamentoViewModel solicitacaoOrcamentoViewModel)
        {
            var obj = new SolicitacaoOrcamento()
            {
               IdSolicitacao = solicitacaoOrcamentoViewModel.IdSolicitacao,
               NomeSolicitacao = solicitacaoOrcamentoViewModel.NomeSolicitacao,
               CelularSolicitacao = solicitacaoOrcamentoViewModel.CelularSolicitacao,
               EmailSolicitacao = solicitacaoOrcamentoViewModel.EmailSolicitacao,
               DescricaoSolicitacao = solicitacaoOrcamentoViewModel.DescricaoSolicitacao,
               EnderecoSolicitacao = solicitacaoOrcamentoViewModel.EnderecoSolicitacao,
               DataSolicitacao = solicitacaoOrcamentoViewModel.DataSolicitacao,
            };

            if (await _solicitacaoOrcamentoService.InserirSolicitacao(obj))
            {
                await this.IncluirAnexoSolicitacao(solicitacaoOrcamentoViewModel.Anexos, obj.IdSolicitacao);
                return true;
            }
            return false;
        }
        public async Task<bool> AtualizarSolicitacao(SolicitacaoOrcamento solicitacaoOrcamento)
        {
            return await _solicitacaoOrcamentoService.AtualizarSolicitacao(solicitacaoOrcamento);
        }

        public async Task<bool> ExcluirAnexo(long IdSolicitacao)
        {
            return await _solicitacaoOrcamentoService.ExcluirAnexo(IdSolicitacao);
        }

        public async Task<bool> ExcluirSolicitacao(long IdSolicitacao)
        {
            await ExcluirAnexo(IdSolicitacao);
            return await _solicitacaoOrcamentoService.ExcluirSolicitacao(IdSolicitacao);
        }

        public async Task<SolicitacaoOrcamento> GetById(long id)
        {
            var solicitacao = await _solicitacaoOrcamentoService.GetById(id);

            if (solicitacao != null)
            {
                var anexos = await _solicitacaoOrcamentoService.ObterAnexos(id);
                solicitacao.Imagens = anexos.ToList();
            }

            return solicitacao;
        }

        public async Task IncluirAnexoSolicitacao(List<IFormFile> anexos, long idSolicitacao)
        {
            if (anexos == null)
                return;

            ICollection<AnexoSolicitacaoOrcamento> anexosSolicitacao = new List<AnexoSolicitacaoOrcamento>();

            foreach (IFormFile anex in anexos)
            {
                AnexoSolicitacaoOrcamento obj = new AnexoSolicitacaoOrcamento(idSolicitacao);
                var extension = anex.FileName.Substring(anex.FileName.IndexOf('.'));

                using (MemoryStream ms = new MemoryStream())
                {
                    await anex.CopyToAsync(ms);
                    obj.InformarExtensao(extension);
                    obj.InformarAnexoBase64(Convert.ToBase64String(ms.ToArray()));

                    anexosSolicitacao.Add(obj);
                }


                await _solicitacaoOrcamentoService.IncluirAnexoSolicitacao(obj);
            }
        }



        public async Task<IEnumerable<AnexoSolicitacaoOrcamento>> ObterAnexos(long IdSolicitacao)
        {
            return await _solicitacaoOrcamentoService.ObterAnexos(IdSolicitacao);
        }

        public async Task<IEnumerable<SolicitacaoOrcamento>> ObterTodosOrcamento(SolicitacaoOrcamento solicitacaoOrcamento)
        {
          return await _solicitacaoOrcamentoService.ObterTodosOrcamento(solicitacaoOrcamento);
        }
    }
}
