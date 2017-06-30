//Para cargar la lista de sedes
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
                    $("#SedeReserva").append('<option disabled="disabled" selected="selected">Seleccione Sede</option>');
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


//Para cargar los horarios disponibles
$(document).ready(function () {
    //Evento change --> Seleccioné una sede
    $("#SedeReserva").change(function () {
        $("#FechaHoraReserva").empty();
        $.ajax({
            type: 'POST',
            url: '../obtenerFechaHoraReserva', // llamada del método json
            dataType: 'json',
            data: { id: $("#SedeReserva").val() },
            success: function (fechas) {
                // fechas tiene la lista en formato Json que se creó en el método
                $("#FechaHoraReserva").append('<option disabled="disabled" selected="selected">Seleccione Fecha</option>');
                $.each(fechas, function (i, fecha) {
                    $("#FechaHoraReserva").append('<option value="' + fecha.Value + '">' + fecha.Text + '</option>');
                }); // Se agregan las opciones al dropdownlist FechaHoraInicioReserva
            },
            error: function (ex) {
                alert('Error al cargar fechas');
            }
        });
        return false;
    })
});