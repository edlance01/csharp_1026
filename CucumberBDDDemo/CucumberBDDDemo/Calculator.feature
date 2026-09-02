Feature: Basic Calculator
  As a user
  I want to add two numbers together
  So that I can avoid doing mental math

  Scenario: Add two positive numbers
    Given I have entered 50 into the calculator
    And I have entered 70 into the calculator
    When I press add
    Then the result should be 120