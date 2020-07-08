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
			checkBox: false,
			radioStacked: null
		},
		methods: {
			sendForm() {
				let fields = [];
				fields.push({
					name: "singleText",
					value: this.singleText
				});
				fields.push({
					name: "dateText",
					value: this.dateText
				});
				fields.push({
					name: "multiText",
					value: this.multiText
				});
				fields.push({
					name: "checkBox",
					value: `${this.checkBox}`
				});
				fields.push({
					name: "multiSelect",
					value: `${this.multiSelect}`
				});
				fields.push({
					name: "radioStacked",
					value: this.radioStacked
				});

				this.sendRequest(fields);
			},
			async sendRequest(fields) {
				await request.postData(submitFormUrl, fields);
			}
		}
	};
};