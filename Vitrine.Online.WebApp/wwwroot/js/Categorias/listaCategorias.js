﻿$(document).ready(() => {



});



function onClickVerCategoria(trabalho) {

    var url = "../Categoria/VerCategoria";

    util.ajax.post(url, trabalho, resultVerTrabalhoSucess, resultVerTrabalhoError);

}


function resultVerTrabalhoSucess(dados) {


    document.write(dados);
}

function resultVerTrabalhoError(error) {

    console.log("Erro")
}


var slideIndex = 1;
showSlides(slideIndex);

function plusSlides(n) {
    showSlides(slideIndex += n);
}

function currentSlide(n) {
    showSlides(slideIndex = n);
}

function showSlides(n) {
    var i;
    var slides = document.getElementsByClassName("mySlides");
    if (n > slides.length) { slideIndex = 1 }
    if (n < 1) { slideIndex = slides.length }
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    slides[slideIndex - 1].style.display = "block";
}