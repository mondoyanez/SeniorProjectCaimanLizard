import { validateInput } from "../../../project/wwwroot/dist/inputValidation.js"
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

    test("validateInput should display you cannot search for yourself if input and current user are the same string", () => {
        // Arrange
        // Create a new DOM environment
        const dom = new JSDOM(`<!DOCTYPE html><html><head></head><body><div id="user-search-input-error-message"></div><table id="users-found"></table></body></html>`);
        const $ = require("jquery")(dom.window);
    
        global.document = dom.window.document;
    
        // Parameters needed for function input
        const input = "mondoyanez";
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
        expect(expectedErrorMessage).toBe("<p>You cannot search for yourself, please enter another username</p>");
        expect(expectedUsersTable).toBe('<table id="users-found" style="display: none;"></table>');
    });

    test("validateInput should display input can only contain alphabetic characters if character starts with a special character", () => {
        // Arrange
        // Create a new DOM environment
        const dom = new JSDOM(`<!DOCTYPE html><html><head></head><body><div id="user-search-input-error-message"></div><table id="users-found"></table></body></html>`);
        const $ = require("jquery")(dom.window);
    
        global.document = dom.window.document;
    
        // Parameters needed for function input
        const input = "@mondoyanez";
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
        expect(expectedErrorMessage).toBe("<p>Input can only contain alphabetic characters</p>");
        expect(expectedUsersTable).toBe('<table id="users-found" style="display: none;"></table>');
    });

    test("validateInput should display input can only contain alphabetic characters if string contains a special character", () => {
        // Arrange
        // Create a new DOM environment
        const dom = new JSDOM(`<!DOCTYPE html><html><head></head><body><div id="user-search-input-error-message"></div><table id="users-found"></table></body></html>`);
        const $ = require("jquery")(dom.window);
    
        global.document = dom.window.document;
    
        // Parameters needed for function input
        const input = "s0meU$%@r";
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
        expect(expectedErrorMessage).toBe("<p>Input can only contain alphabetic characters</p>");
        expect(expectedUsersTable).toBe('<table id="users-found" style="display: none;"></table>');
    });

    test("validateInput should display something went wrong if input string is null", () => {
        // Arrange
        // Create a new DOM environment
        const dom = new JSDOM(`<!DOCTYPE html><html><head></head><body><div id="user-search-input-error-message"></div><table id="users-found"></table></body></html>`);
        const $ = require("jquery")(dom.window);
    
        global.document = dom.window.document;
    
        // Parameters needed for function input
        const input = null;
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
        expect(expectedErrorMessage).toBe("<p>Something went wrong please try again</p>");
        expect(expectedUsersTable).toBe('<table id="users-found" style="display: none;"></table>');
    });

    test("validateInput should display nothing for errorMessageBody since no error ocurred and return true for valid input and table should be displayed", () => {
        // Arrange
        // Create a new DOM environment
        const dom = new JSDOM(`<!DOCTYPE html><html><head></head><body><div id="user-search-input-error-message"></div><table id="users-found"></table></body></html>`);
        const $ = require("jquery")(dom.window);
    
        global.document = dom.window.document;
    
        // Parameters needed for function input
        const input = "sandraHart";
        const currentUser = "mondoyanez";
        const re = /^[A-Za-z]+$/;
        const errorMessageElement = $("#user-search-input-error-message");
        const usersTableElement = $("#users-found");
    
        // Act
        const isValidInput = validateInput(input, currentUser, re, errorMessageElement, usersTableElement);
        const expectedErrorMessage = document.getElementById("user-search-input-error-message").innerHTML;
        const expectedUsersTable = document.getElementById("users-found").outerHTML;
    
        // Assert
        expect(isValidInput).toBe(true);
        expect(expectedErrorMessage).toBe("");
        expect(expectedUsersTable).toBe('<table id="users-found"></table>');
    });
});