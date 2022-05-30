$(document).ready(function () { //click
    GetAll();
    EstadoGetAll();
});

function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:10001/Empleado/Get',
        success: function (result) { //200 OK
            $('#SubCategorias tbody').empty();
            $.each(result.Objects, function (i, empleado) {
                var filas = '<tr>' + '<td class="text-center"> ' + '<a href="#" onclick="GetById(' + empleado.IdEmpleado + ')">' + '<img  style="height: 25px; width: 25px;" src="../img/edit.ico" />' + '</a> ' + '</td>'+ "<td  id='id' class='text-center'>" + empleado.IdEmpleado + "</td>"+ "<td class='text-center'>" + empleado.NumeroNomina + "</td>" + "<td class='text-center'>" + empleado.Nombre + "</td>" + "<td class='text-center'>" + empleado.ApellidoPaterno + "</ td>" + "<td class='text-center'>" + empleado.ApellidoMaterno + "</td>" + "<td class='text-center'>" + empleado.Estado.Nombre + "</td>"
                        //+ '<td class="text-center">  <a href="#" onclick="return Eliminar(' + subCategoria.IdSubCategoria + ')">' + '<img  style="height: 25px; width: 25px;" src="../img/delete.png" />' + '</a>    </td>'
                        + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + empleado.IdEmpleado + ')"><span class="glyphicon glyphicon-trash" style="color:#FFFFFF"></span></button></td>'

                    + "</tr>";
                $("#SubCategorias tbody").append(filas);
            });
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};

function Add(empleado) {

    $.ajax({
        type: 'POST',
        url: 'http://localhost:10001/Empleado/Add',
        dataType: 'json',
        data: JSON.stringify(empleado),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            $('#myModal').modal();
            $('#ModalUpdate').modal('hide');
            GetAll();
        }
    });
};

function GetById(IdEmpleado) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:10001/Empleado/GetById/?IdEmpleado=' + IdEmpleado,
        success: function (result) {
            $('#txtIdEmpleado').val(result.Object.IdEmpleado);
            $('#txtNumeroNomina').val(result.Object.NumeroNomina);
            $('#txtNombre').val(result.Object.Nombre);
            $('#txtApellidoP').val(result.Object.ApellidoPaterno);
            $('#txtApellidoM').val(result.Object.ApellidoMaterno);
            $('#ddlEstado').val(result.Object.Estado.IdEstado);

            $('#ModalUpdate').modal('show');
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }


    });

}

function EstadoGetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:10001/Estado/GetAll',
        success: function (result) {
            $("#ddlEstado").append('<option value="' + 0 + '">' + 'Seleccione una opción' + '</option>');
            $.each(result.Objects, function (i, estado) {
                $("#ddlEstado").append('<option value="'
                                           + estado.IdEstado + '">'
                                           + estado.Nombre + '</option>');
            });
        }
    });
}

function Update(empleado) {

    $.ajax({
        type: 'POST',
        url: 'http://localhost:19004/api/Empleado/Update',
        datatype: 'json',
        data: JSON.stringify(empleado),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            $('#myModal').modal();
            $('#ModalUpdate').modal('hide');
            GetAll();
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });

};

function Modal() {
    var mostrar = $('#ModalUpdate').modal('show');
    IniciarEmpleado();

}

function Eliminar(IdEmpleado) {

    if (confirm("¿Estas seguro de eliminar el empleado seleccionado?")) {
        $.ajax({
            type: 'GET',
            url: 'http://localhost:10001/Empleado/Delete/?IdEmpleado=' + IdEmpleado,
            success: function (result) {
                $('#myModal').modal();
                GetAll();
            },
            error: function (result) {
                alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
            }
        });

    };
};

function Actualizar() {
    var empleado = {
        IdEmpleado: $('#txtIdEmpleado').val(),
        NumeroNomina: $('#txtNumeroNomina').val(),
        Nombre: $('#txtNombre').val(),
        ApellidoPaterno: $('#txtApellidoP').val(),
        ApellidoMaterno: $('#txtApellidoM').val(),
        Estado: {
            IdEstado: $('#ddlEstado').val()
        }
    }

    if (empleado.IdEmpleado == '') {
        Add(empleado);

    }
    else {
        Update(empleado);
    }
}

function IniciarEmpleado() {

    var empleado = {
        IdEmpleado: $('#txtIdEmpleado').val(''),
        NumeroNomina: $('#txtNumeroNomina').val(''),
        Nombre: $('#txtNombre').val(''),
        ApellidoPaterno: $('#txtApellidoP').val(''),
        ApellidoMaterno: $('#txtApellidoM').val(''),
        Estado: {
            IdEstado: $('#ddlEstado').val(0)
        }
    }
}