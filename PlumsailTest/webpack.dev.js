/* global require, module */

const path = require("path");
const webpack = require("webpack");
const merge = require("webpack-merge");

const commonConfiguration = require("./webpack.config");

let developmentConfiguration = merge(commonConfiguration, {
	mode: "development",
	devtool: "source-map"
});

module.exports = developmentConfiguration;