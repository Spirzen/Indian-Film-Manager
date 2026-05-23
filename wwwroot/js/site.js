document.addEventListener('DOMContentLoaded', () => {
    document.querySelectorAll('form[data-confirm-delete]').forEach((form) => {
        form.addEventListener('submit', (e) => {
            if (!confirm('Удалить эту запись? Действие нельзя отменить.')) {
                e.preventDefault();
            }
        });
    });
});
