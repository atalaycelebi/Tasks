/*
2 Database Queries
 I used nested queries for part 2,3 and p4 . I believe we can make it with inner join (hybrid with nested query) as well. For performance, they might be rewritten with the help of query analyzer and similar tools if they are determined to cause bottlenecks. In my last project I had similar structure and relations. I used Linq query to get the result for similar queries. I currently don't have  access to that server instance to see what is the created query at SQL server from those Linq requests, whicih is another option to obtain possibly more efficient query.

Part 1

Assuming mentioned date is 12 Jan 2015
*/
SELECT *
FROM Exercise
WHERE CreatedDate >='2019-01-13'


--Part 2

SELECT *
FROM Exercise
WHERE ExerciseID IN
(
SELECT ExerciseID
FROM ExerciseMuscle
WHERE MuscleID =
 (
SELECT MuscleID
FROM Muscle
WHERE MuscleName='Bicep'
 )
)

--Part 3

SELECT *
FROM Exercise
WHERE ExerciseID IN
(
SELECT ExerciseID
FROM ExerciseMuscle
WHERE MuscleID IN
 (
SELECT MuscleID
FROM Muscle
WHERE MuscleName='Bicep' OR MuscleName='Tricep'
 )
)

--Part 4

DECLARE @bicepID  int;
DECLARE @tricepID  int;

SET @bicepID = (Select MuscleID from Muscle where MuscleName='Bicep')
SET @tricepID  = (Select MuscleID from Muscle where MuscleName='Tricep')
SELECT *
FROM Exercise
where ExerciseID in
(
SELECT ExerciseID
FROM ExerciseMuscle
WHERE MuscleID = @bicepID  and ExerciseID IN
  (
SELECT ExerciseID
FROM ExerciseMuscle
WHERE MuscleID = @tricepID
  )
)
