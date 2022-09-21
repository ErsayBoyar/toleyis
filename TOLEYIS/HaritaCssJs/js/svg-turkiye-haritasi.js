/*! SVG Türkiye Haritası | MIT Lisans | dnomak.com */

function svgturkiyeharitasi() {
    const element = document.querySelector('#svg-turkiye-haritasi');
    const info = document.querySelector('.il-isimleri');

    element.addEventListener(
        'mouseover',
        function (event) {
            if (event.target.tagName === 'path' && event.target.parentNode.id !== 'guney-kibris') {
                info.innerHTML = [
                    '<div>',
                    event.target.parentNode.getAttribute('data-iladi'),
                    '</div>'
                ].join('');
            }
        }
    );

    
    element.addEventListener(
        'mousemove',
        function (event) {

            //console.log(`X Mouse X: ${event.clientX}, Mouse Y: ${event.clientY}`);
            //console.log(`event X: ${event.pageX}, event Y: ${event.pageY}`);
            info.style.top = event.pageY / 2.2 + 'px';
            info.style.left = event.pageX / 1.2 + 'px';
            //info.style.top = event.pageY + 25 + 'px';
            //info.style.left = event.pageX  + 'px';
            //info.style.top = next_pos.x /3 + 'px';
            //info.style.left = next_pos.y /3+ 'px' ;
        }
    );

    element.addEventListener(
        'mouseout',
        function (event) {
            info.innerHTML = '';
        }
    );

    element.addEventListener(
        'click',
        function (event) {
            if (event.target.tagName === 'path') {
                const parent = event.target.parentNode;
                const id = parent.getAttribute('id');

                if (id === 'guney-kibris') {
                    return;
                }
                window.location.href = (
                    '#'
                    + id
                    + '-'
                    + parent.getAttribute('data-plakakodu')
                );
                var selectedUser = parent.getAttribute('data-plakakodu');
                var path = window.location.pathname;
                if (path == "/Toleyis/SubeDetay") {
                    var urlToHit = '/Toleyis/SubeIlSec?durum=1';
                }
                else if (path == "/Toleyis/IlTemsilcilik") {
                    var urlToHit = '/Toleyis/TemsilcilikIlSec';
                }
                else if (path == "/Toleyis/Orgutlu") {
                    var urlToHit = '/Toleyis/IlSec';
                }
                else if (path == "/Bilgi/AnlasmaliKurumlar") {
                    var urlToHit = '/Bilgi/IlSec';
                }
                else if (path == "/ToleyisEN/SubeDetay") {
                    var urlToHit = '/ToleyisEN/SubeIlSec?durum=1';
                }
                else if (path == "/ToleyisEN/IlTemsilcilik") {
                    var urlToHit = '/ToleyisEN/TemsilcilikIlSec';
                }
                else if (path == "/ToleyisEN/Orgutlu") {
                    var urlToHit = '/ToleyisEN/IlSec';
                }
                else if (path == "/Info/AnlasmaliKurumlar") {
                    var urlToHit = '/Info/IlSec';
                }
                $.ajax({
                    url: urlToHit,
                    cache: false,
                    type: "POST",
                    data: { id: selectedUser },
                    success: function (data) {
                        $("#dvUserDetails").html(data);
                        $(`#drpiller option[value=${selectedUser}]`).attr('selected', 'selected');
                        document.getElementsByClassName('svg-turkiye-haritasi').setAttribute("style", "width:100px");
                    },
                    error: function () {
                        alert("failed");
                    }
                });
            }
        }
    );
}
