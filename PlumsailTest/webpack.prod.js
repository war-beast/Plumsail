/* global require, __dirname, module */

const merge = require("webpack-merge");

const commonConfiguration = require("./webpack.config");

let configuration = merge(commonConfiguration, {
	mode: "production"
});

module.exports = configuration;