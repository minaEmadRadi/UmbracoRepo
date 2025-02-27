
    function GetformatedDate(dateString) 
     {
        if (!dateString) return 'N/A';
        const lang = window.currentLanguage === "ar" ? "ar-EG" : window.currentLanguage;
        return new Date(dateString).toLocaleDateString(lang, {
            weekday: 'long',
            year: 'numeric',
            month: 'long',
            day: 'numeric'
        });
    }

    function buildCroppedImageUrl(imageData) {
        if (!imageData?.url) return '';

        const ListingCrop = imageData.crops?.find(crop => crop.alias === BlogGlobals.umbraco.imageCroplistAlias);
        if (!ListingCrop) return '';

        const { coordinates, width, height } = ListingCrop;
        const baseUrl = `${ window.location.origin}${imageData.url}`;

        if (coordinates) {
            const { x1, y1, x2, y2 } = coordinates;
            return `${baseUrl}?cc=${x1},${y1},${x2},${y2}&width=${width}&height=${height}`;
        }

        return `${baseUrl}?cc=0,0,0,0&width=${width}&height=${height}`;
    }
