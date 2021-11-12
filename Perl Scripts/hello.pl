#!/user/bin/perl
use warnings;

package Hierarchy;
sub new {
    my $class = shift;
    my $self = {
        AccountId => shift,
        SubAccountId => shift,
        Enrolled => shift,
        Proxy_Ballot => shift
        }; 
    
    bless $self, $class;
    return $self;
    
}

sub TO_JSON { return { %{ shift() } }; }
package main;
use DBI;
use JSON;
use 5.010;
my $JSON = JSON->new->utf8;
$JSON->convert_blessed(1);

my $data_source = q/dbi:ODBC:localexpress/;
my $user = q/shri_h/;
my $password = q/shrihari@123/;

# Connect to the data source and get a handle for that connection.
my $dbh = DBI->connect($data_source, $user, $password) 
    or die "Can't connect to $data_source: $DBI::errstr";
    my $sth = $dbh->prepare("select * from Test.dbo.tbl");
$sth->execute();

my $fileName = 'C:\Documents\Hierarchy.json';
open(my $fh, '>>', $fileName) or die "Could not open file";

while ( my @row = $sth->fetchrow_array ) {
        $e = new Hierarchy($row[0], $row[1], $row[2], $row[3]);
        $json = $JSON->encode($e);
        #print "$json\n";
        say $fh $json;
}
close $fh


