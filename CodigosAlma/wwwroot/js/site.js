function EnviarCorreo() {
    // Obtener el valor del contacto (por ejemplo, de un input)
    var contacto = $("#contactoInput").val(); // Ajusta el selector según tu HTML
    console.log(contacto);

    // Validación del parámetro
    if (!contacto || contacto.trim() === '') {
        Swal.fire({
            icon: 'warning',
            title: 'Atención',
            text: 'Por favor, ingrese un contacto válido',
        });
        return; // Detiene la ejecución si no hay contacto
    }

    // Mostrar alerta de "Enviando"
    Swal.fire({
        title: 'Enviando...',
        allowOutsideClick: false,
        showConfirmButton: false,
        didOpen: () => {
            Swal.showLoading();
        }
    });

    var endpoint = getDomain() + "/SendMail/EnviarCorreo";
    $.ajax({
        type: "POST",
        url: endpoint,
        contentType: "application/json",
        data: JSON.stringify({ contacto: contacto }), // Enviar el contacto como JSON
        dataType: "json",
        success: function (data) {
            // Cerrar alerta de "Enviando"
            Swal.close();

            if (data.success) {
                // Mostrar alerta de "Enviado"
                Swal.fire({
                    icon: 'success',
                    title: 'Enviado',
                    text: data.message,
                });
            } else {
                // Mostrar alerta de error
                Swal.fire({
                    icon: 'error',
                    title: 'Error',
                    text: 'Hubo un error al enviar el contacto: ' + data.message,
                });
            }
        },
        error: function (xhr, status, error) {
            // Cerrar alerta de "Enviando"
            Swal.close();

            // Mostrar alerta de error
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'No se pudo enviar el contacto',
            });
        }
    });
}