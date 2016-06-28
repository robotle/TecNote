CREATE TABLE DBUSER ( 
  USER_ID       NUMBER (5)    NOT NULL, 
  USERNAME      VARCHAR2 (20)  NOT NULL, 
  CREATED_BY    VARCHAR2 (20)  NOT NULL, 
  CREATED_DATE  DATE          NOT NULL, 
  PRIMARY KEY ( USER_ID ) 
 );
 
 
create or replace type CUR is ref CURSOR;
 
 CREATE OR REPLACE PROCEDURE getDBUSERCursor(
	   p_username IN DBUSER.USERNAME%TYPE,
	   c_dbuser OUT SYS_REFCURSOR )
IS
BEGIN

  OPEN c_dbuser FOR
  SELECT * FROM DBUSER WHERE USERNAME LIKE p_username || '%';
 
END;
/

DECLARE 
  c_dbuser SYS_REFCURSOR;
  temp_dbuser DBUSER%ROWTYPE;
BEGIN
 
  --records are assign to cursor 'c_dbuser'
  getDBUSERCursor('mkyong',c_dbuser);
 
  LOOP
 
        --fetch cursor 'c_dbuser' into dbuser table type 'temp_dbuser'
	FETCH c_dbuser INTO temp_dbuser;
 
        --exit if no more records
        EXIT WHEN c_dbuser%NOTFOUND;

        --print the matched username
        dbms_output.put_line(temp_dbuser.username);
 
  END LOOP;
 
  CLOSE c_dbuser;
 
END;
/
