$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/kullanıcı/rapor/getall' },
        "columns": [
            { data: 'raporId', "width": "5%" },
            { data: 'raporTarih', "width": "15%" },
            { data: 'raporYazar', "width": "5%" },
            { data: 'açılışKotu', "width": "15%" },
            { data: 'kapanışKotu', "width": "15%" },
            { data: 'açmaListesi.açmaAdı', "width": "15%" },
            {
                data: 'raporId',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                        <a href="/kullanıcı/rapor/Upsert/?id=${data}" class="btn btn-primary mx-2">
                              <i class="bi bi-pencil-square"></i>Düzenle
                        </a>
                        <a href="/kullanıcı/rapor/Details/?id=${data}" class="btn btn-primary mx-2">
                              <i class="bi bi-pencil-square"></i>Detaylar
                        </a>
                        <a onClick=Delete('/kullanıcı/rapor/RaporSil/${data}') class="btn btn-danger mx-2">
                                <i class="bi bi-trash"></i> Sil
                        </a>
                </div>`
                },
                "width": "15%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Silmek istediğine emin misin?',
        text: "Bu işlem geri alınamaz!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Evet, Sil!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);

                }
            })
        }
    })
}