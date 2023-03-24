import { generateHeaders, generateTableBody } from "../../../project/wwwroot/dist/manipulateDomUsers.js"
const { JSDOM } = require("jsdom");
const he = require("he");

describe("testing functionality of manipulateDomUsers.js", () => {
  test("generateHeaders should modify table and generate table headers", () => {
    // Arrange
    // Create a new DOM environment
    const dom = new JSDOM(`<!DOCTYPE html><html><head></head><body><table id="users-found"></table></body></html>`);
  
    // Get the document and window objects from the DOM environment
    const { document } = dom.window;
    const usersTableElement = document.getElementById("users-found");
  
    // Act
    generateHeaders(usersTableElement);
  
    // Assert
    const expected = he.decode(usersTableElement.innerHTML.replace(/[\n\t\s]+/g, ""));
    const actual = '<tr><th>Username</th><th>Email</th><th>FirstandLastName</th></tr>';
  
    expect(expected).toBe(actual);
  });
  
  test("generateTableBody should modify table and generate table body", () => {
      // Arrange
      // Create a new DOM environment
      const dom = new JSDOM(`<!DOCTYPE html><html><head></head><body><table id="users-found"><tr><th>Username</th><th>Email</th><th>FirstandLastName</th></tr></table></body></html>`);
  
      // Get the document and window objects from the DOM environment
      const { document } = dom.window;
      const usersTableElement = document.getElementById("users-found");
  
      // Act
      generateTableBody(usersTableElement);
  
      // Assert
      const expected = he.decode(usersTableElement.innerHTML.replace(/[\n\t\s]+/g, ""));
      const actual = '<tbody><tr><th>Username</th><th>Email</th><th>FirstandLastName</th></tr></tbody><tbodyid=\"user-tbody\"></tbody>';
  
      expect(expected).toBe(actual);
  });
});