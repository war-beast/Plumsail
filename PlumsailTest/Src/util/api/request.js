import axios from "axios";
import RequestException from "Exceptions/requestException";

export default class Request {
	constructor() {
		let sendGetRequest = async function(url) {
			return await axios.get(url,
				{
					headers: {
						"Accept": "application/json"
					}
				}).then((result) => {
				return {
					success: true,
					value: result.data
				};
			}).catch((error) => {
				if (error.response.data !== undefined && error.response.data !== "") {
					console.error(new RequestException(url), error.response.data);
					return {
						success: false,
						value: error.response.data.title
					};
				} else {
					console.error(new RequestException(url), error.message);
					return {
						success: false,
						value: error.message
					};
				}
			});
		}

		let sendPostRequest = async function(url, data) {
			return await axios.post(url,
				JSON.stringify(data),
				{
					headers: {
						"Accept": "application/json",
						"Content-type": "application/json;charset=utf-8"
					}
				}).then((result) => {
				return {
					success: true,
					value: result.data
				};
			}).catch((error) => {
				if (error.response.data !== undefined && error.response.data !== "") {
					console.error(new RequestException(url), error.response.data);
					return {
						success: false,
						value: error.response.data.title
					};
				} else {
					console.error(new RequestException(url), error.message);
					return {
						success: false,
						value: error.message
					};
				}
			});
		}


		this.getData = async function (url) {
			return await sendGetRequest(url)
				.then((result) => {
					return result;
				});
		}

		this.postData = async function (url, customer) {
			return await sendPostRequest(url, customer)
				.then((result) => {
					return result;
				});
		}
	}
}