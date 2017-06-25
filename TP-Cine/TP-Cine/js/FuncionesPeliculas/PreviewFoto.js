  function previewFile() {
        var preview = document.querySelector('img');
        var file = document.querySelector('input[type=file]').files[0];
        var reader = new FileReader();

        reader.addEventListener("load", function () {
            preview.src = reader.result;
        }, false);

        if (file) {
            reader.readAsDataURL(file);
        }
}

/*function HabilitarDeshabilitarFormCreacionEditPeliculas(modo) {
    if (modo == "ver") {
          $('#pelicula_Nombre').prop('disabled', true);
          $('#Calificaciones').prop('disabled', true);
          $('#Generos').prop('disabled', true);
          $('#pelicula_Imagen').prop('disabled', true);
          $('#pelicula_Descripcion').prop('disabled', true);
          $('#pelicula_Duracion').prop('disabled', true);
          $('#agregar').hide();
      } else if (modo == "editar") {
          $("#agregar").text('Editar');
      }
}*/