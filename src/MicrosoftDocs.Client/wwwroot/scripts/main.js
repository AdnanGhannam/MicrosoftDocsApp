
function addEventToWindow(id) {
    window.addEventListener('mouseup', function (event) {
        let menu = document.querySelector('[data-id="' + id + '"]');
        var box = document.getElementById("menu-cb-" + id);
        if (menu && box && !menu.contains(event.target)) {
            box.checked = false;
        }
    });
}
