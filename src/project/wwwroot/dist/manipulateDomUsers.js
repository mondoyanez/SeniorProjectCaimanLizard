export function generateHeaders(usersTableBody) {
    const headers = `
        <tr>
            <th>Username </th>
            <th> Email </th>
            <th> First and Last Name </th>
            <th> Amount Following </th>
            <th> Amount of Followers </th>
        </tr>
    `;
    usersTableBody.append(headers);
}
export function generateTableBody(usersTable) {
    const tBody = "<tbody id=\"user-tbody\"></tbody>";
    usersTable.append(tBody);
}
//# sourceMappingURL=manipulateDomUsers.js.map