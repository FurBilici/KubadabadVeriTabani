$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblBuluntuData').DataTable({
        "ajax": { url: '/kullanıcı/buluntu/getall' },
        "columns": [
            { data: 'buluntuId', "width": "5%" },
            { data: 'buluntuTürü', "width": "15%" },
            { data: 'buluntuTarih', "width": "15%" },
            { data: 'evre', "width": "15%" },
            { data: 'buluntuKotu', "width": "15%" },
            { data: 'açmaListesi.açmaAdı', "width": "15%" },
            {
                data: 'buluntuId',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                        <a href="/kullanıcı/buluntu/Upsert/?id=${data}" class="btn btn-primary mx-2">
                              <i class="bi bi-pencil-square"></i>Düzenle
                        </a>
                        <a href="/kullanıcı/buluntu/Details/?id=${data}" class="btn btn-primary mx-2">
                              <i class="bi bi-pencil-square"></i>Detaylar
                        </a>
                        <a onClick=Delete('/kullanıcı/buluntu/BuluntuSil/${data}') class="btn btn-danger mx-2">
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