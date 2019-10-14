$(document).ready(function () {
    $('#employeeTable').DataTable({
        language: {
            processing: "Carregando tabela...",
            search: "Buscar",
            lengthMenu: "Mostrar _MENU_ itens",
            info: "Mostrando entre _START_ e _END_ de um total de _TOTAL_ funcion\u00e1rios",
            infoEmpty: "0 Itens encontrados",
            infoFiltered: "Itens filtrados",
            infoPostFix: "",
            loadingRecords: "Carregando conteúdo da tabela...",
            zeroRecords: "N\u00e3o h\u00e1 elementos condizentes com a busca.",
            emptyTable: "Essa tabela est\u00e1 vazia.",
            paginate: {
                first: "Primeiro",
                previous: "Anterior",
                next: "Pr\u00f3ximo",
                last: "\u00daltimo"
            },
            aria: {
                sortAscending: "Ordem crescente",
                sortDescending: "Ordem decrescente"
            }
        }
    });
});

function deleteTableRow(trId) {
    let deleteConfirmation = confirm("Voc\u00ea tem certeza que deseja deletar este usu\u00e1rio?");
    if (deleteConfirmation !== false) {
        const httpRequest = new Request;
        httpRequest.delete('api/' + trId, function (err, response) {
            if (err) {
                console.log(err);
            }
            else {
                console.log(response);
                document.getElementById('tr_' + trId).classList.add('deleted');
                document.getElementById('tr_' + trId).style.display = "none";
                alert("Usu\u00e1rio deletado com sucesso.");
            }
        });
    }
}