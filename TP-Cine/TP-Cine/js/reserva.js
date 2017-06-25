    $(document).ready(function () {
        //Evento change --> Seleccioné una versión 
        $("#VersionReserva").change(function () {
            $("#SedeReserva").empty();
            $.ajax({
                type: 'POST',
                url: '../obtenerSedeReserva', // llamada del método json
                dataType: 'json',
                data: { id: $("#VersionReserva").val() },
                success: function (sedes) {
                    // sedes tiene la lista en formato Json que se creó en el método
                    $.each(sedes, function (i, sede) {
                        $("#SedeReserva").append('<option value="' + sede.Value + '">' + sede.Text + '</option>');
                    }); // Se agregan las opciones al dropdownlist SedeReserva
                },
                error: function (ex) {
                    alert('Error al cargar sedes');
                }
            });
            return false;
        })
    });
