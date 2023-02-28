describe('Documents: When opening the overview', () => {
  beforeEach(() => cy.visit('/'));

  it('displays the heading', () => {
    cy.contains('Dokumente');
  });
});
