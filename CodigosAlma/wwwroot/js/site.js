function EnviarCorreo() {
    fetch('/SendMail/EnviarCorreo', {
        method: 'POST'
    })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                console.log(data.message); // Muestra el mensaje de éxito en la consola
                alert(data.message); // Muestra una alerta con el mensaje de éxito
            } else {
                console.error('Error:', data.message);
                alert('Hubo un error al enviar el correo: ' + data.message); // Muestra una alerta con el mensaje de error
            }
        })
        .catch(error => {
            console.error('Error:', error);
            alert('Hubo un error al enviar el correo');
        });
}
