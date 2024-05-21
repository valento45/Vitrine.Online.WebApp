$(document).ready(() => {



});




function onClickCarregarImagens(e) {


    $('#btnCarregarImagens').click();
}


function onChangeImagens(e) {

    var qtdAnexos = e.files.length;


    $("#lblQtdAnexos").text(`( ${qtdAnexos} )`);
}


function onClickSalvar(e) {

    var model = new Object();
    model.Anexos = new FormData();

    model.IdServico = +$("#txtCodigo").val();
    model.DescricaoServico = $("#txtDescricao").val();
    model.DataServico = $("#txtData").val();
    model.IdCategoria = $("#textCategoria").val();
    model.EnderecoServico = $("#txtLocal").val();
    model.ResumoServico = $("#txtResumo").val();
   


    var inputFiles = document.getElementById('btnCarregarImagens');


    if (inputFiles.files.length > 0) {
        for (var indice = 0; indice < inputFiles.files.length; indice++) {
            model.Anexos.append('files', inputFiles.files.item(indice));
        }
    }


    util.ajax.post("../ServicoRealizado/SalvarServico", model,
        (data) => {
            console.log(data);
        },

        (error) => {
            console.log(error);
        });
}