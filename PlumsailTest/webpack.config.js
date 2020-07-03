const path = require("path");
const webpack = require("webpack");
const CleanWebpackPlugin = require("clean-webpack-plugin");
const { VueLoaderPlugin } = require("vue-loader");
const BundleAnalyzerPlugin = require("webpack-bundle-analyzer").BundleAnalyzerPlugin;

const NODE_ENV = process.env.NODE_ENV || "development";
const isProductionMode = NODE_ENV === "production";
const isDebugMode = NODE_ENV === "development";
// Путь к выходной папке
const bundleFolder = "wwwroot/bundle/";

let configuration = {
	entry: {
		mainPage: "./Src/pages/main/initialize.js"
	},
	output: {
		filename: "[name].bundle.js",
		publicPath: bundleFolder,
		path: path.resolve(__dirname, "./wwwroot/bundle"),
		chunkFilename: "[name].bundle.js"
	},
	optimization: {
		splitChunks: {
			minSize: 30000,
			maxInitialRequests: Infinity,
			cacheGroups: {
				vendors: {
					test: /[\\/]node_modules[\\/]/,
					name: "vendors",
					chunks: "initial",
					enforce: true,
					minChunks: 2,
					priority: -30
				}
			}
		}
	},
	plugins: [
		//new BundleAnalyzerPlugin(), // Раскомментить для анализа бандлов
		new VueLoaderPlugin(),
		
		new CleanWebpackPlugin([bundleFolder])
	],
	resolve: {
		extensions: [".js", ".vue", ".json"],
		alias: {
			vue$: "vue/dist/vue.esm.js",
			Vue$: "vue/dist/vue.esm.js",

			MainPage: path.resolve(__dirname, "./Src/pages/main/")
		}
	},
	module: {
		rules: [
			{
				test: /\.vue$/,
				loader: "vue-loader",
				options: {
					loaders: {
						js: [{ loader: "babel-loader" }]
					}
				}
			},
			{
				test: /\.js$/,
				exclude: /node_modules/,
				use: {
					loader: "babel-loader"
				}
			},
			{
				test: /\.less$/,
				use: ["vue-style-loader", "css-loader", "less-loader"]
			},
			{
				test: /\.css$/,
				use: ["vue-style-loader", "css-loader"]
			}
		]
	}
};

module.exports = configuration;