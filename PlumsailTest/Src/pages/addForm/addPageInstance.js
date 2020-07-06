import ApiRequest from "Api/request";

const request = new ApiRequest();
const submitFormUrl = "/api/common/createItem";

export default () => {
	return {
		el: "#vue-add-form",
		data: {
			singleText: null,
			dateText: null,
			multiText: null,
			multiSelect: [],
			checkBox: null,
			radioStacked: null
		},
		methods: {
			sendForm() {
				let st = {
					singleText: this.singleText,
					dateText: this.dateText,
					multiText: this.multiText,
					checkBox: this.checkBox,
					multiSelect: this.multiSelect,
					radioStacked: this.radioStacked
				}

				let str = JSON.stringify(st);

				this.sendRequest(str);
			},
			async sendRequest(str) {
				let data = {
					serializedJsonValue: str
				}

				await request.postData(submitFormUrl, data);
			}
		}
	};
};