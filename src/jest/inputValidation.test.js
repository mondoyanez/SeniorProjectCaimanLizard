/*
import { validateInput } from "../project/wwwroot/dist/inputValidation.js";
const { JSDOM } = require("jsdom");
const he = require("he");
const $ = require("jquery");

test("validateInput should display username is required for empty string", () => {
    // Arrange
    // Create a new DOM environment
    const dom = new JSDOM(`<!DOCTYPE html><html><head></head><body><div id="user-search-input-error-message"></div><table id="users-found"></table></body></html>`);

    global.window = dom;
    global.document = dom.document;

    // Parameters needed for function input
    const input = "";
    const currentUser = "mondoyanez";
    const re = /^[A-Za-z]+$/;
    const errorMessageElement = $("#user-search-input-error-message");
    const usersTableElement = $("#users-found");

    // Act
    const isValidInput = validateInput(input, currentUser, re, errorMessageElement, usersTableElement);

    // Assert
    expect(isValidInput).toBe(false);
});
*/
import { validateInput } from "../project/wwwroot/dist/inputValidation.js";
const { JSDOM } = require("jsdom");
const he = require("he");

describe("testing functionality of inputValidation.js", () => {
    test("validateInput should display username is required for empty string", () => {
        // Arrange
        // Create a new DOM environment
        const dom = new JSDOM(`<!DOCTYPE html><html><head></head><body><div id="user-search-input-error-message"></div><table id="users-found"></table></body></html>`);
        const $ = require("jquery")(dom.window);
    
        global.document = dom.window.document;
    
        // Parameters needed for function input
        const input = "";
        const currentUser = "mondoyanez";
        const re = /^[A-Za-z]+$/;
        const errorMessageElement = $("#user-search-input-error-message");
        const usersTableElement = $("#users-found");
    
        // Act
        const isValidInput = validateInput(input, currentUser, re, errorMessageElement, usersTableElement);
        const expectedErrorMessage = document.getElementById("user-search-input-error-message").innerHTML;
        const expectedUsersTable = document.getElementById("users-found").outerHTML;
    
        // Assert
        expect(isValidInput).toBe(false);
        expect(expectedErrorMessage).toBe("<p>This is a required field, please enter a username</p>");
        expect(expectedUsersTable).toBe('<table id="users-found" style="display: none;"></table>');
    });
});