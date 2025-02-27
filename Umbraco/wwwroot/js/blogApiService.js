class BlogApiService {
    static async fetchBlogItems(pageNumber ,language ) {
        const skip = (pageNumber - 1) * BlogGlobals.pagination.itemsPerPage;

        try {
            const response = await $.ajax({
                url: `${window.location.origin}${BlogGlobals.api.endpoints.content}`,
                method: "GET",
                timeout: 0,
                headers: {
                    "Accept-Language": language,
                    "Api-Key": BlogGlobals.api.headers.apiKey
                },
                data: {
                    filter: `contentType:${BlogGlobals.umbraco.itemAlias}`,
                    skip: skip,
                    take: BlogGlobals.pagination.itemsPerPage
                }
            });

            return response;
        } catch (error) {
            console.error('Error fetching blog items:', error);
            throw new Error(BlogGlobals.localization.translations[language].errors.loadFailed);
        }
    }

}
