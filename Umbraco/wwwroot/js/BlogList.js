class BlogList {

    static renderBlogItem(item) {
        const dir = window.currentLanguage === "ar" ? "rtl" : "ltr";
        const croppedImageUrl = buildCroppedImageUrl(item.properties.headerImage);
        const formattedDate = GetformatedDate(item.createDate);

        return `
            <hr class="my-4" />
            <div class="row" dir="${dir}">
                <div class="post-preview col-9">
                    <a href="${item.route.path}">
                        <h2 class="post-title">${item.properties.title}</h2>
                    </a>
                    <a href="${item.route.path}">
                        <h3 class="post-subtitle">${item.properties.subtitle}</h3>
                    </a>
                    <span class="badge bg-secondary">${item.properties.categories[0]?.name || 'Uncategorized'}</span>
                    <p class="post-meta" style="display: inline;">
                        ${formattedDate}
                    </p>
                </div>
                <div class="col-3">
                    ${croppedImageUrl ? `<img src="${croppedImageUrl}" alt="${item.properties.title}" class="img-fluid mb-3 list-image" />` : ''}
                </div>
            </div>
            <hr class="my-4" />
        `;
    }
    static renderPagination(currentPage, totalItems, itemsPerPage) {
        const currentTranslations = BlogGlobals.localization.translations[window.currentLanguage] || BlogGlobals.localization.translations['en'];
        const hasNextPage = (currentPage * itemsPerPage) < totalItems;
        const hasPrevPage = currentPage > 1;

        return `
            <div class="d-flex ${window.currentLanguage === 'ar' ? 'flex-row-reverse' : ''} justify-content-between mb-4">
                ${hasPrevPage ?
                `<a class="btn btn-primary text-uppercase" onclick="BlogList.loadPage(${currentPage - 1})">${currentTranslations.back}</a>`
                : ''}
                ${hasNextPage ?
                `<a class="btn btn-primary text-uppercase" onclick="BlogList.loadPage(${currentPage + 1})">${currentTranslations.next}</a>`
                : ''}
            </div>
        `;
    }

    static async loadPage(pageNumber) {
        $('#partial-content').html('');

        try {
            const response = await BlogApiService.fetchBlogItems(pageNumber, window.currentLanguage);

            let contentHtml = response.items
                .map(item => this.renderBlogItem(item))
                .join('');

            const paginationHtml = this.renderPagination(
                pageNumber,
                response.total,
                BlogGlobals.pagination.itemsPerPage
            );

            $('#partial-content').html(contentHtml + paginationHtml);
        } catch (error) {
            alert('Failed to load data. Please try again later.'+error);
        }
    }

    static init() {
        $(document).ready(() => {
            this.loadPage(1);
        });
    }
}