import ApiRequest from "Api/request";

const request = new ApiRequest();

export default () => {
	return {
		el: "#vue-add-form",
		data: {
			success: "Vue loading ok!"
		},
		methods: {
			sendForm() {

			}
		}
	};
};