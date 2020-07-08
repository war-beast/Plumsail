import ApiRequest from "Api/request";

const request = new ApiRequest();
const submitFormUrl = "/api/common/getSearchResult";

export default () => {
	return {
		el: "#vue-search-form",
		data: {
			searchResult: null,
			phrase: null,
			formValid: true,
			error: null
		},
		methods: {
			search() {
				this.formValid = this.checkValid();
				if (this.formValid)
					this.sendRequest(`${submitFormUrl}?phrase=${this.phrase}`);
			},
			checkValid() {
				return this.phrase !== null && this.phrase !== "";
			},
			async sendRequest(url) {
				this.error = null;

				await request.getData(url)
					.then((result) => {
						if (result.success)
							this.showResult(JSON.parse(result.value));
						else
							this.error = result.value;
					});
			},
			showResult(result) {
				this.searchResult = result;
			}
		}
	};
};