$(document).ready(function () {
    //myfunction1();
    myfunction2();
});

function myfunction1() {
    $.ajax({
        url: 'http://localhost:55514/api/khachhang/GetChiPhiHopDong?mahd=14556',
        type: 'GET',
        contentType: 'application/json',
        success: function (d) {
            var table = $('#tbl-chiphi-hopdong');
            let html = '';
            $.each(d, function (a, b) {
                html += '<tr>';
                html += '<td>' + b.MaHD + '</td>';
                html += '<td>' + b.TenKH + '</td>';
                html += '<td>' + b.MaCB + '</td>';
                html += '<td>' + b.NgayNhap + '</td>';
                html += '<td>' + b.NoiDungChiPhi + '</td>';
                html += '<td>' + b.SoTien + '</td>';
                html += '<td><a class="" href="#"><i class="fa fa-edit"></i></a></td>';
                html += '<td><a class="" href="#"><i class="fa fa-trash"></i></a></td>';
                html += '</tr>';
            });
            table.find('tbody').html(html);
        },
        error: function (err) {

        }
    });
}

function myfunction2() {
    $.ajax({
        url: 'http://localhost:55514/api/khachhang/GetAll',
        type: 'GET',
        contentType: 'application/json',
        success: function (d) {
            var table = $('#tbl-tonghop-khachhang');
            let html = '';
            $.each(d, function (a, b) {
                html += '<tr>';
                html += '<td>'+(a+1)+'</td>';
                html += '<td>' + b.MaKH + '</td>';
                html += '<td>' + b.MaHD+'</td>';
                html += '<td>' + b.MaDG + '</td>';
                html += '<td>' + b.TenKH + '</td>';
                html += '<td>' + b.TieuChuan+'</td>';
                html += '<td>' + b.NguoiMoiGioi + '</td>';
                html += '<td>' + b.NguoiPhuTrach + '</td>';
                html += '<td>' + b.DoanhThu + '</td>';
                html += '<td>' + b.DoanhThuThuNgiem + '</td>';
                html += '<td>0343</td>';
                html += '<td>' + b.VAT + '</td>';
                html += '<td>' + b.SoHD + '</td>';
                html += '<td>' + b.NgayCapCC + '</td>';
                html += '<td>' + b.NgayCCDi + '</td>';
                html += '<td>' + b.lan1 + '</td>';
                html += '<td>' + b.lan2 + '</td>';
                html += '<td>' + b.lan3 + '</td>';
                html += '<td>' + b.chiphidanhgia + '</td>';
                html += '<td>' + b.chiphihoahong + '</td>';
                html += '<td>' + b.chiphihoso + '</td>';
                html += '<td>chi chú</td>';
                html += '</tr>';
            });
            table.find('tbody').html(html);
        },
        error: function (err) {

        }
    });
}