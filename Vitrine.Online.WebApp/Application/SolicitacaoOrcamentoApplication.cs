using Vitrine.Online.Core.Models.SolicitacaoOrcamento;
using Vitrine.Online.Core.Services.Intefaces;
using Vitrine.Online.WebApp.Application.Interfaces;
using Vitrine.Online.WebApp.Models;

namespace Vitrine.Online.WebApp.Application
{
    public class SolicitacaoOrcamentoApplication : ISolicitacaoOrcamentoApplication
    {
        private readonly ISolicitacaoOrcamentoServices _solicitacaoOrcamentoServices;
        public SolicitacaoOrcamentoApplication(ISolicitacaoOrcamentoServices solicitacaoOrcamentoServices)
        {
            _solicitacaoOrcamentoServices = solicitacaoOrcamentoServices;
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

            if (await _solicitacaoOrcamentoServices.InserirSolicitacao(obj))
            {
                await this.IncluirAnexoSolicitacao(solicitacaoOrcamentoViewModel.Anexos, obj.IdSolicitacao);
                return true;
            }
            return false;
        }
        public Task<bool> AtualizarSolicitacao(SolicitacaoOrcamento solicitacaoOrcamento)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExcluirAnexo(long IdSolicitacao)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExcluirSolicitacao(long IdSolicitacao)
        {
            throw new NotImplementedException();
        }

        public Task<SolicitacaoOrcamento> GetById(long id)
        {
            throw new NotImplementedException();
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


                await _solicitacaoOrcamentoServices.IncluirAnexoSolicitacao(obj);
            }
        }



        public Task<IEnumerable<AnexoSolicitacaoOrcamento>> ObterAnexos(long IdSolicitacao)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SolicitacaoOrcamento>> ObterTodosOrcamento(SolicitacaoOrcamento solicitacaoOrcamento)
        {
            throw new NotImplementedException();
        }
    }
}
