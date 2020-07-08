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
					sendRequest(`${submitFormUrl}?phrase=${this.phrase}`);
			},
			checkValid() {
				return this.phrase !== null;
			},
			async sendRequest(url) {
				this.error = null;

				await request.getData(url)
					.then((result) => {
						if (result.success)
							this.showResult(result.value);
						else
							this.error = result.value;
					});
			},
			showResult(result) {
				var res = result;
			}
		}
	};
};